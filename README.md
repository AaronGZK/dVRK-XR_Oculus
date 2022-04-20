# Structure of Project
- dvrk_oculus_unity_project:
	- A unity project that contains prefabs, models and scripts of this project.
	- The project is implemented on Windows (64-bit operating system, x64-based).
	- The Unity version is 2020.3.29f1c1.
- UDP_example:
	- A python-based sample server and client.
	- Remember to change the IP address (the IP address of the server) and the port.

# How to Run

- Change the IP address and port number in the Start() function of dvrk_oculus_unity_project/Assets/UDPSender.cs.
- Build the Unity project into Oculus.
- Please make sure that the server code running before opening the Oculus program built by Unity.
