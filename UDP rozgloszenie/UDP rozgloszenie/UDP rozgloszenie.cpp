// UDP komunikacja prsota.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <cstdio>
#include <WinSock2.h>
#include <iostream>
#include <string.h>

using namespace std;

class wyjatek
{
	DWORD dwError;
public:
	wyjatek(int iResult)
	{
		printf ("Winsock - Blad nr %d",iResult);		
	}

	wyjatek (hostent *rH)
	{
			dwError = WSAGetLastError();
			if (dwError == WSAHOST_NOT_FOUND)
			{
				printf ("host not found");
			}
			else if (dwError = WSANO_DATA)
			{
				printf ("no data record");
			}
			else
			{
				printf ("failed %d",dwError);
			}
	}
};

class TInicjalizacja
{
	int iResult;
	WSAData wsaData;
	int dwError;
public:
	TInicjalizacja()
	{
		iResult = WSAStartup (MAKEWORD (2,2), &wsaData);
		if (iResult != 0)
		{
			
			throw wyjatek(iResult);
		}
		else
		{
		//	printf ("Winosck jest oki\n");
		}
	}
	~TInicjalizacja()
	{
		WSACleanup();
	}

};

class THost
{
	int iResult;
	DWORD dwError;
	hostent *rH;
	char hostname[100];
	sockaddr_in serwer;
	sockaddr_in klient;
public:
	THost (const char *nazwa)
	{
		strcpy (hostname,nazwa);
		rH = gethostbyname(hostname);
		if (rH == NULL) throw wyjatek (rH);		
		else
		{
			serwer.sin_family = AF_INET;
			serwer.sin_port = htons (5000);
			serwer.sin_addr.s_addr = (INADDR_BROADCAST);

			//
			klient.sin_family = AF_INET;
			klient.sin_port = htons (300);
			klient.sin_addr.s_addr = htonl (INADDR_ANY);
		}
	}

	hostent ZwrocHostent()
	{
		return *rH;
	}

	sockaddr_in Zwrocserwer()
	{
		return serwer;
	}
	
	sockaddr_in Zwrocklient()
	{
		return klient;
	}

};

int _tmain(int argc, _TCHAR* argv[])
{
	
	TInicjalizacja TW;
	
	
/////////////////////////////////////////////////////////////
	SOCKET Client;
	Client = socket (AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (Client == INVALID_SOCKET)
	{
		cout << "Nie mozna stworzyc socket" << endl;
		getch();
		return 1;
	}

	const char on=1;
	char* czas="1";
	if (setsockopt (Client,SOL_SOCKET, SO_BROADCAST, &on, sizeof(on) ) <0)
	{
			cout <<"Blad setsockopt nr:" << WSAGetLastError();
			shutdown (Client,2);
			closesocket (Client);
			getch();
			return 1;
	}

//	sockaddr_in moj_Addr;
//	moj_Addr.sin_port = htons (300); // port
//////////////////////////////////////////////////////////////////
	char host[128] = "127.0.0.1";

	THost Th (host);
//////////////////////////////////////////////////////////////////////////////////////s
	char buffliczb[1024];
	int suma=0;
//	char buff[1024];
	char ciag [1024];

	char buff2[1024];
	int buffLen = 1024;
	int AddrSize; //= sizeof (Addr);
	char wyslanymsg[1024];

	int wynik;

	wynik = bind (Client,(SOCKADDR*)&Th.Zwrocklient(), sizeof(Th.Zwrocklient() ) );
	if (wynik == SOCKET_ERROR)
	{
		cout <<"Blad bindowania nr:" << WSAGetLastError();
		shutdown (Client,2);
		closesocket (Client);
		getch();
		return 1;
	}

	int Random;
	while (true)
	{
		Random = 1+(rand()%50);
		int x;
		x= _kbhit();
		if (x!=0)
		{
			if (getch() == VK_ESCAPE) break;

			itoa (Random,wyslanymsg,10);
			
			int wynik = sendto (Client,wyslanymsg,strlen(wyslanymsg),0,(SOCKADDR*)&Th.Zwrocserwer(),sizeof (Th.Zwrocserwer() ) );
			if (wynik == SOCKET_ERROR)
			{
				cout <<"Blad bindowania nr:" << WSAGetLastError();
				shutdown (Client,2);
				closesocket (Client);
				getch();
				return 1;
			}
			else
			{
	//			cout <<"Wyslane";
			}

			int AddrSize = sizeof (Th.Zwrocklient());
			wynik = recvfrom (Client,buff2,buffLen,0,(SOCKADDR*)&Th.Zwrocklient(),&AddrSize);
			if (wynik <0)
			{
				cout <<"Blad odbierania nr:" << WSAGetLastError();
				shutdown (Client,2);
				closesocket (Client);
				getch();
				return 1;
			}
			else
			{
				cout << "Odebrane" << endl;	
				sscanf("%d",buff2);
				suma += atoi (buff2);
				cout << "Adres: " << Th.ZwrocHostent().h_name << endl;
				cout << "Port: " << ntohs (Th.Zwrocserwer().sin_port) << endl;
				cout << "Suma: " << suma << endl;
			
			}
		}
	}

	cout << "Koniec programu" << endl;
	getch();
	return 0;

}