# OOP.CourseProject

Simple WPF project, created as a course project in the university within bounds of OOP course.
This application provides quite simple functionallity that allows you to do some "simple management" of abstract public transport(Tram, bus etc.). You can create/update/delete and view listed data. Also you can search(Filter) through all characteristics by defining an instance and choosing the comparer(greater/lower/etc.) and orderby options(ASC|DSC|NO)
All data is stored in the local JSON-files.
Application defines simple IDataService interface(and class implementing it) to manage data, and FileManager to manipulate files.
Some methods of Transport class(Save, export etc.) are defined in DB entities due to needs of Course Project Technical Task
