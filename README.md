# Color Cord Web App

An MVC Core Web App that utilizes a custom color matching API and provides corresponding color schemes based on user input

## Authors: Andrew Hinojosa, Jason Few, Deziree Teague

## Summary:

When the user hit the home page there will be 2 links one for pets and one for the individual. Once the user clicks the link, they will be redirected to their saved color scheme page, there will be seperate saved paged for pets and people. If there are saved results, the user can update or delete their saved color schemes. Otherwise the user can go to the search page and search for a color harmony and save if they like the color scheme.

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
