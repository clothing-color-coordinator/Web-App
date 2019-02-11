# Color Cord Web App

Deployed on Azure: https://colorscheme.azurewebsites.net/

## Introduction

Color Cord is an MVC Core Web App that utilizes a custom color matching API.  The purpose of this application is to give users a tool to make color coordination quick and easy. Whether it's finding the perfect outfit to wear, picking out home decor, or figuring out the right shade of paint, Color Cord can help!  Users are able to search for color matches based on a preferred color palette such as complementary, analogous, or triadic.  Users may also save their results for future reference. 

## Usage

On the landing page, the user can navigate to "Color Search" or "Users"

![home](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/home.JPG)

Users can enter a color to search and select a preferred color palette from the dropdown box

![search](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/search.JPG)

The results page displays color matches along with the corresponding hex codes.  The user can select their name from the dropdown box and save the results.

![results](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/results.JPG)

Users can edit their username, access saved color schemes, and delete themselves from the system

![users](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/users.JPG)

By clicking the "My saved colors" link, users are able to view and delete color matches that have been previously saved

![savedmatches](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/savedmatches.JPG)

## Database Schema

![colormatchdb](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/colormatchdb.JPG)

The database contains two tables: one for the individual user and another for color schemes.  The individual has a 1:many relationsip with color schemes because each individual user can have many color schemes associated with their user ID.  User id is a foreign key in the color scheme table.  The color scheme table also has an enum "Scheme Type" which refers to the various color palettes available to choose from.    

## Wireframes

Home Page

![Home Page](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/wf-home.JPG)

Color Scheme Search

![Color Scheme Search](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/wf-search.JPG)

Results

![Results](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/wf-results.JPG)

Users

![Users](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/wf-users.JPG)

Saved Color Matches

![Saved colors](https://github.com/clothing-color-coordinator/Web-App/blob/master/Assets/wf-savedmatches.JPG)

## Tools Used

Visual Studio, GitHub, LINQ, Bootstrap, Microsoft.AspNetCore, Microsoft.EntityFramework, Microsoft.NET.Test.Sdk 

## API 

Color Wheel API https://github.com/clothing-color-coordinator/API

## Contributors

Jason Few, Deziree Teague, Andrew Hinojosa

#### MIT License

https://github.com/clothing-color-coordinator/Web-App/blob/master/LICENSE

#### Version

Version 1.0  February 01, 2019