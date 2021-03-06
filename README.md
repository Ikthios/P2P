# P2P
This README will explain the innerworkings of the Clinet P2P system

[Preparations]
1) Create a folder in the C: drive called 'Clinet' without the quotes.
2) Create/put files into the Clinet folder you just created.

[Running the Server]
At startup, the server will automatically grab the localhost's IP address and start hosting on port 6000 (TCP) and 6001 (UDP). HELLO packets will be sent to the server from the peer at even intervals. The server will register when a peer sends a HELLO packet and will delete the peer when a HELLO packet is not received after 2 minutes.

[Explaining the Client]
There are five sections to the client form:
1) File Search
This is where the user will input a file to search for by entering the desired filename
with the extension and hitting the 'Search' button.
2) Peer Listing
This is where messages from the server relating to peer (client) activities are shown to
all the connected clients.
3) Server Connection Status
This is where the server IP address and the hosting port are entered. The user will click
the connect button which will connect to and register the peer with the server.
4) Download Manager
(Under Development)
5) Menu Bar
  A) Client
    New Client: Open up a new client window
    Exit: Exit the client
  B) Server
    Start Internal: Start the client's internal server
    Disconnect: Disconnect the client from the server
  C) ?
    About: About window for the client
    Help: Help window for the client

[Running the Client]
After starting the client the user will have to perform two tasks, starting the internal server
to handle peer requests and connecting to the server. After these tasks are performed the user
can begin to search for files, which will automatically be downloaded by the client.
