// UDP komunikacja prsota.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <cstdio>
#include <WinSock2.h>
#include <iostream>

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
	sockaddr_in addr;
public:
	THost (const char *w)
	{
		strcpy (hostname,w);
		rH = gethostbyname(hostname);
		if (rH == NULL) throw wyjatek (rH);		
		else
		{
			addr.sin_addr.s_addr = inet_addr (hostname);
		}
	}

	hostent ZwrocHostent()
	{
		return *rH;
	}

	sockaddr_in ZwrocAddr()
	{
		return addr;
	}
};

int _tmain(int argc, _TCHAR* argv[])
{
	
	TInicjalizacja TW;
	sockaddr_in Addr;
	
	char buff[1024];
	int buffLen = 1024;
	int AddrSize; //= sizeof (Addr);

/////////////////////////////////////////////////////////////
	SOCKET Serwer;
	Serwer = socket (AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (Serwer == INVALID_SOCKET)
	{
		cout << "Nie mozna stworzyc socket" << endl;
		getch();
		return 1;
	}

	Addr.sin_family = AF_INET;
	Addr.sin_port = htons (0); // port
	Addr.sin_addr.s_addr = htonl (INADDR_ANY);

	bind(Serwer, (SOCKADDR*)&Addr, sizeof(Addr));
	do {
		int n = recvfrom(Serwer, buff, buffLen, 0, (SOCKADDR*)&Addr, &AddrSize);
		buff[n] = 0;
		printf("%s\n",buff);
	} while (stricmp(buff, "exit"));
	shutdown(Serwer, 2);
	closesocket(Serwer);
	WSACleanup();
	return 0;



	getch();
	return 0;

}