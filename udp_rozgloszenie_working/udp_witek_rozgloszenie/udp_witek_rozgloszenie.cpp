// UDP komunikacja prsota.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <cstdio>
#include <WinSock2.h>
#include <iostream>
#include <string.h>
#include <vector>

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
/*
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
*/

struct Adresowa
{
	char adres[16];
	int liczba;
};

struct Odb
{
	int liczba;
	char znak[32];
};

int Sprawdz (int czas, SOCKET gniazdo)
{
	timeval timer = {czas/1000,(czas%1000)*1000};
	fd_set set;
	FD_ZERO (&set);
	FD_SET (gniazdo,&set);
	int wyjscie = select (FD_SETSIZE,&set,NULL,NULL,&timer);
	return wyjscie;
}

int _tmain(int argc, _TCHAR* argv[])
{
	vector<Adresowa>dane;
	
	//srand(time(NULL));
	

	TInicjalizacja TW;
	
/////////////////////////////////////////////////////////////
	SOCKET gniazdo;
	gniazdo = socket (AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (gniazdo == INVALID_SOCKET)
	{
		cout << "Nie mozna stworzyc socket" << endl;
		getch();
		return 1;
	}

	bool optVal = true;
	if ( (setsockopt (gniazdo,SOL_SOCKET,SO_BROADCAST,(char*)&optVal,sizeof(bool))) == SOCKET_ERROR)
	{
		cout << "blad setsockopt" << endl;
		getch();
		return 1;
	}

	//tworzenie RECV

	sockaddr_in pobierz;
	pobierz.sin_family = AF_INET;
	pobierz.sin_addr.s_addr = INADDR_ANY;
	pobierz.sin_port = htons(5000);

	// tworzenie SENDTO
	sockaddr_in wyslij;
	wyslij.sin_family = AF_INET;
	wyslij.sin_port = htons (5000);
	wyslij.sin_addr.s_addr = INADDR_BROADCAST;

	//BINDOWANIE

	if ((bind(gniazdo,(SOCKADDR*)&pobierz,sizeof (pobierz))) == SOCKET_ERROR)
	{
		cout << "blad";
		getch();
		return 1;
	}

	while(true)
	{
		int x = _kbhit();
		if(x!=0)
		{
			if (getch() == VK_ESCAPE) break;

			int zmienna = (rand()%20)+20;
			
			if ((sendto (gniazdo,(char*)&zmienna,sizeof(int),0,(SOCKADDR*)&wyslij,sizeof(wyslij))) == SOCKET_ERROR)
			{
				cout << "blad";
				getch();
				return 1;
			}

			cout << "Wyslalem zmienna: " << zmienna << endl;
		}
		else
		{
			if (Sprawdz (0,gniazdo) > 0)
			{
				char odebrane[64];
				memset (odebrane,0,sizeof(odebrane));
				int rozm = sizeof(pobierz);
				if ((recvfrom (gniazdo,odebrane,sizeof(odebrane),0,(SOCKADDR*)&pobierz,&rozm)) == SOCKET_ERROR)
				{
					cout << "blad";
					getch();
					return 1;
				}
				bool flaga = true;

				for (int i=0; i<dane.size(); i++)
				{
					if (strcmp (inet_ntoa (pobierz.sin_addr),dane[i].adres) == 0)
					{
						dane[i].liczba += (((Odb*)odebrane)->liczba);
						flaga = false;
					}

					printf ("%s::%i \n", dane[i].adres,dane[i].liczba);
				}
				if(flaga)
				{
					Adresowa obiekt;
					strcpy (obiekt.adres,inet_ntoa(pobierz.sin_addr));
					obiekt.liczba = (((Odb*)odebrane)->liczba);
					dane.push_back(obiekt);
					for (int i=0; i<dane.size(); i++)
					{
						printf ("%s:%i \n",dane[i].adres,dane[i].liczba);
					}
				}
			}
		}


	}



	cout << "Koniec programu" << endl;
	getch();
	return 0;

}