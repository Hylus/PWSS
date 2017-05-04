// Wysylnaie_UDP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <cstdio>
#include <WinSock2.h>
#include <iostream>
#include <string.h>

int _tmain(int argc, _TCHAR* argv[])
{
	char buff[1024];
	buff[1024] = '123';
	WSADATA wsaData;
	SOCKET Socket;
	sockaddr_in Addr;
	WSAStartup (MAKEWORD (2,2), &wsaData);
	Socket = socket (AF_INET,SOCK_DGRAM,IPPROTO_UDP);
	Addr.sin_family = AF_INET;
	Addr.sin_port = htons (5000);
	Addr.sin_addr.s_addr = inet_addr ("127.0.0.1");
	do
	{
	//	buff[1024] = '12';
		gets(buff);
		sendto (Socket,buff,strlen(buff),0,(SOCKADDR*)&Addr,sizeof(Addr));
	}while(stricmp (buff,"exit"));

	shutdown (Socket,2);
	closesocket(Socket);
	WSACleanup();
	return 0;
}

