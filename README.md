# CrazyflieTracking
Clone the repository into a folder on your computer, or just download it as a zip file<br />
If downloading as a zip file, unzip the file into a folder<br />
Open the unity hub, and click add (upper right side), which will allow you to browse your computer and select the recently downloaded folder<br />
This should add the folder as a new unity project in your unity hub<br />
Make sure you have unity version 2020.3.26f1 downloaded, with android build support selected to install as well<br />
Setup and plug in the base stations, keeping them in opposite corners, with a clear view of the tracker (obstructions will keep the tracker from working)<br />
Follow the steps detailed in the "CrazyflieTutorial" document to set up the crazyflie tracker<br />
If the tracking is to be done wirelessly, uncomment line 18 of the "connect_log_param.py" file<br />
Else, if wired tracking is preferred, make sure line 19 is not commented, and line 18 is commented out<br />
The unity packages installed allow this program to work on an oculus device, through the oculus link<br />
Connect an oculus device to the computer, using a link cable<br />
It may ask you to go through the room setup, where it will guide you through a process to set the floor height and draw a guardian boundary<br />
Open SteamVR, and make sure the headset is connected<br />
Make sure the oculus app is installed on the computer<br />
Enable the oculus link on the headset, making sure the oculus rift hub shows<br />
Place the headset just above the crazyflie tracker in real space, leave it there until the unity program starts running<br />
Run the connect_log_param.py file by using the command “python3 connect_log_param.py” in the same directory the file is found in<br />
Once you run this command, the server is looking for something to connect to, and it should find it as soon as you play the unity project<br />
The unity program should now be running with the tracker in virtual space moving as it is in the real world<br />
