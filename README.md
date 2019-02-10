# Color Cord Web App

![azure deployment](https://colorscheme.azurewebsites.net/)

## Introduction

Color Cord is an MVC Core Web App that utilizes a custom color matching API.  The purpose of this application is to give users a tool to make color coordination quick and easy. Whether it's finding the perfect outfit to wear, picking out home decor, or figuring out the right shade of paint, Color Cord can help!  Users are able to search for color matches based on a preferred color palette such as complementary, analogous, or triadic.  Users may also save their results for future reference. 

## Usage

![home](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/home.JPG)

![search](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/search.JPG)

![results](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/results.JPG)

![users](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/users.JPG)

![savedmatches](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/savedmatches.JPG)


## API (JSON format)
Color Wheel API

#### Version:
```
Version 1.0  February 01, 2019
```

## Web App Wireframes

Home Page

![Home Page](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/1-Homepage.png)

Color Scheme Search

![Color Scheme Search](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/2-Color-Scheme-Search.png)

My Results

![myHuman Results](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/3-myHuman-Results.png)


## Web App Database Wireframes

![colormatchdb](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/colormatchdb.JPG)

The database contains two tables: one for the individual user and another for their pet.  The individual has 0-1: 1 relationsip with the pet using the primary id from the pet as a foreign key.
