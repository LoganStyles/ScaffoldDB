#!/bin/sh
sqlite3 output/School.db <<EOF
CREATE TABLE IF NOT EXISTS Students (
    "Id" INTEGER NOT NULL,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS Courses (
    "Id" INTEGER NOT NULL,
    "Title" TEXT NOT NULL,
    "InstructorId" INTEGER NOT NULL UNIQUE,
    PRIMARY KEY("Id" AUTOINCREMENT),
    FOREIGN KEY (InstructorId) REFERENCES Instructors (Id)
);
CREATE TABLE IF NOT EXISTS Instructors (
    "Id" INTEGER NOT NULL,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL,
    PRIMARY KEY("Id" AUTOINCREMENT)
);
EOF