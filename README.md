# Overview
A small project where the user can Add, Read, Update, Delete through a contacts list. Contacts contain
information of a person. Contacts can be assigned categories which can similarly be managed. 

User can send email and SMS (provided their carrier provides an email to sms gateway) of the contact.


# Requirements
- [X] This is an application where you should record contacts with their phone numbers.

- [X] Users should be able to Add, Delete, Update and Read from a database, using the console.

- [X] You need to use Entity Framework, raw SQL isn't allowed.

- [X] Your code should contain a base Contact class with AT LEAST {Id INT, Name STRING, Email STRING and Phone Number(STRING)}

- [X] You should validate e-mails and phone numbers and let the user know what formats are expected

- [X] You should use Code-First Approach, which means EF will create the database schema for you.

- [X] You should use SQL Server, not SQLite


## Additional challenges
- [X] Create a functionality that allows users to add the contact's e-mail address and send an e-mail message from the app.

- [X] Expand the app by creating categories of contacts (i.e. Family, Friends, Work, etc).

- [X] What if you want to send not only e-mails but SMS?