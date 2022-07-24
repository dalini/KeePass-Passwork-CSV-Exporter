# KeePass-Passwork-CSV-Exporter
Exports credentials from KeePass via CSV for Passwork including folders and notes.

# Functionality
Exports all credentials from KeePass in CSV for Passwork CSV-Import. Includes folders, subfolders and notes. Attachements and additional data are not possible via the CSV Import for Passwork. This might work with the JSON import/export of Passwork, as this supports all fields I think but is not part of this CSV exporter.
Note: Empty folders are not exported.

## Supported Fields
Following data will be exported - as supported by the CSV importer of Passwork: 
- Name
- Login
- Password
- Url
- Note
- Folder

# How to use
## Install the Plugin
Copy the *PassworkExport.dll* or *PassworkExport-1.0.0-Source.plgx* file into the KeePass plugin folder, (re)start KeePass. For more details have a look at: https://keepass.info/help/v2/plugins.html.

## Export Data from KeePass
*Security Advice:* Before you export your data into an unencrypted csv for transfer to another password manager, take some precautions like using a secured virtual storage (e.g. https://github.com/veracrypt/VeraCrypt) or similar and please don't forget to remove the data once imported, also from the 'Trash Bin'.

1. Go to File -> Export

 ![image](https://user-images.githubusercontent.com/849650/180642272-9be27131-bd07-42b1-9418-9db0f6b4ab28.png)
 
2. You might have to scroll down in the list of available plugins
 
 ![image plugin dialog list of KeePass](https://user-images.githubusercontent.com/849650/180642329-99e5476b-93f0-4178-b66b-e7d1fa02d244.png)

3. Select the "Passwork CSV Format" 

4. Provide an target file in the Destination File Dialog below.
 
 ![image destination file dialog for export](https://user-images.githubusercontent.com/849650/180642875-27388315-bd86-4b3f-b315-9b878bd0d3e2.png)

5. Hit *OK* and there you go - all your credentials are now exposed in an unencrypted(!) CSV file on the target destination provided.

Don't forget to delete (also in the Trash Bin!) after importing! 


## Import Data into Passwork 5.x
*Note:* Import validated with and screenshots are from version 5.x - so 4.x might look different or doesn't work as expected.

*Note:* In case something goes wrong or doesn't work as expected: it might advisable to import the data into a separate folder first. All the folders from the CSV will be created in the same structure as in KeePass before.

1. Choose the vault and folder to get the data imported into and open the Import Data dialog.

  ![image](https://user-images.githubusercontent.com/849650/180643197-85790a07-0b74-4983-826e-81bb9a8b3560.png)
 
2. Default selection might be JSON -> click on CSV to open the CSV import dialog

  ![image import dialog](https://user-images.githubusercontent.com/849650/180643941-0bfff5d0-0736-493c-970a-9d2c5f44bf18.png)  

3. Choos a delimiter (Auto and *;*) should both work and mark "Skip the first line"

  ![image selection of import settings](https://user-images.githubusercontent.com/849650/180643348-c29e525e-8754-4284-96e9-3574a3aad379.png)

4. Klick Next and map all the columns - the should be in the same order as Passwork expects them (eventually they can automate this in the future! Passwork - do you here me? ;)

  ![image field mapping dialog](https://user-images.githubusercontent.com/849650/180643394-70512abf-caa5-4410-b142-a529b500cda3.png)
  ![image mapping a field](https://user-images.githubusercontent.com/849650/180643427-81018a95-d8b2-4dc5-8fe9-55640ecd3905.png)

5. After mapping the fields it should look something like this:

  ![image after mapping fields](https://user-images.githubusercontent.com/849650/180643421-572efd6c-566d-443a-8558-5f10ad9ca79c.png)

6. Hit next, check the preview and hit next again to get to the confirmation of the import target:

  ![image review mapped data](https://user-images.githubusercontent.com/849650/180643851-533a477e-ca76-4723-adb7-b65ab33281ec.png)
 
7. you might change the import target in this step again to another destination or confirm the target (sometimes you have to refresh the client side data):
 
  ![image confirm/select your import target](https://user-images.githubusercontent.com/849650/180643607-205d5211-2683-480e-8007-fde898bc6040.png)
 
8. and there you go:

  ![image folders after import inside passwork](https://user-images.githubusercontent.com/849650/180644244-35346a83-4077-4bd8-9d32-c2ddde887478.png)
  ![image entries in one folder after import](https://user-images.githubusercontent.com/849650/180644296-2f8b7f1d-8385-48da-8f27-550211419318.png)

# How to compile yourself
1. Checkout the code
2. Update the KeePass.exe Reference
3. Build

# Credits
Based on the theVault CSV exporter for KeePass from Bruce NZ https://keepass.info/plugins.html#thevault - source code available via keepass site.
