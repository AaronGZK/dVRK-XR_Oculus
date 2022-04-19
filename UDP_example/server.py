#!/usr/bin/env python3
import socket

localIP = "172.31.254.155"
localPort = 34567
bufferSize = 1024

msgFromServer = "Hi Client! This is Server."
bytesToSend = str.encode(msgFromServer)


# create Datagram socket
UDPServerSocket = socket.socket(family=socket.AF_INET, type= socket.SOCK_DGRAM)

# bind to address and ip
UDPServerSocket.bind((localIP,localPort))
print("UDP server is up and listening ")

# listen for incomming dstagrams 
while(True):
    bytesAddressPair = UDPServerSocket.recvfrom(bufferSize)
    message = bytesAddressPair[0]
    address = bytesAddressPair[1]
    clientMSG =  "message from client : {}".format(message)
    clientIP = "client IP Address : {}".format(address)
    
    print(clientMSG)
    print(clientIP)

    #sending a reply to client
    UDPServerSocket.sendto(bytesToSend, address)
