# **Aegis: Anti-Forensics Windows Implementation**

**Aegis** is a implementation of the anti-forensics projects [Silk-Guardian](https://github.com/NateBrune/silk-guardian) and [xxUSBSentinel](https://github.com/thereisnotime/xxUSBSentinel?tab=readme-ov-file). It is designed to protect sensitive data and strengthen disk encryption security, focusing on preventing malicious actors from tampering with or extracting data during unauthorized access.  

## **Why Use Aegis?**  

- **Prevent Tampering**: Protect sensitive data from unauthorized access or manipulation by malicious actors.  
- **Enhanced Security**: Add extra layers of protection to disk encryption, safeguarding your system from physical access threats.  

## **Key Features**  

- **USB Activity Detection**:  
   Automatically shuts down the computer when unauthorized USB activity is detected, mitigating risks of data theft or compromise.  
   
- **Blue Screen of Death (BSOD)**:  
   Triggers a optional BSOD when unauthorized USB activity is present by terminating critical system process `svchost.exe`  

- **Auto-Launch on Startup**:  
   Automatically starts the software on system boot for ease of use and consistent protection.  

## Screenshotsf
![afbeelding](https://github.com/user-attachments/assets/c4b8d87f-9ab9-4b5c-ac07-24b61d2d6f8c)

![afbeelding](https://github.com/user-attachments/assets/5f54b22b-df17-4e9e-b136-79e9fe3c85af)


## **To-Do / Ideas**  

- **Remote Kill Switch**:  
   Implement a remote kill switch using a unique identifier stored in a smart contract on the blockchain. This would enable the system to be remotely disabled in critical situations.  

