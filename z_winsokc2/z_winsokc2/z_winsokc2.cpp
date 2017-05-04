// z_winsokc2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <WinSock.h>
#include <cstdio>
#include <cstdlib>
#include <winsock2.h>

		
int _tmain(int argc, _TCHAR* argv[])
{
	WSADATA wsaData;
	int result = WSAStartup( MAKEWORD( 2, 2 ), & wsaData );
	if( result != NO_ERROR ) printf( "Initialization error.\n" );




	return 0;
}

