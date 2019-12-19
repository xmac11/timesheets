# timesheets
Group project for the 2019 Mind the &lt;Code> program in .NET Core

### Description
Web-based application for registering employee timesheets. Users can be assigned one or more of the following roles: 
- Admin: Super-user capable of viewing and creating new Users, Projects and Timesheets, as well as viewing statistics.
- Manager: Capable of viewing all employees managed by him/her, creating timesheets for them, viewing all projects their department is involved in, as well as viewing statistics. 
- Employee: Capable of viewing and creating new timesheets for a project he/she is involved in.

### E-R Diagram
<img src="https://www.dropbox.com/s/geqbgm9eaasgg7s/schema.png?dl=0&raw=1" width="480">

- A Project can involve many Departments; A Department can be involved in many Projects; (many-to-many)
- A Project can be owned by one Department; A Department can be the owner of many Projects (one-to-many)
- A Timesheet Entry belongs to one User; A User can have many Timesheet Entries (one-to-many)
- A User belongs to one Department; A Department has many Users (one-to-many)
- A Department has one Department Head (one-to-one)
- A User is managed by one User (one-to-one)

### Screenshots
![Screenshots](https://www.dropbox.com/s/0gzyl3qo29w039g/printscreens2.png?dl=0&raw=1)

### Statistics
![Charts](https://www.dropbox.com/s/z4hmpjlceorl0pm/charts.png?dl=0&raw=1)

### Team
- [Charalampos Makrylakis](https://github.com/xmac11)
- [Aristidis Kallergis](https://github.com/ArisKallergis)
- [Iosif Gemenitzoglou](https://github.com/gemeiosi)
- [Konstantinos Tsaknias](https://github.com/Qbique)
- [Dimitrios Pitsios](https://github.com/Jim-Pit)

Instructor: [George Sovatzis](https://github.com/gsovatzis)
