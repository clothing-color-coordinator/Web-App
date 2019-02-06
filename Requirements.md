# Vision

The purpose of The Color Wheel API is to provide a one stop resource for developers color needs.

The vision of the application, is to create a tool that allows a user to save color schemes for themselves and their pets.

You should care about our product becuase it is fun and useful.  You will never flash with the clothing colors of your per again.

# Scope In

The API will provide the developer with a color palette based on a color request.

The API will provide the developer with a variety of color harmonies.

The API will let the developer know if a color scheme matches a requested color palette.

The application will take in the user inputs color and type of color scheme they would like receive.

The application will be able to provide a color scheme for both the user.

The application will allow the user to save edit and delete their color schemes.

The application will allow the user to view saved color schemes.

# Scope Out

The API will not give the developer all of the color palettes in a single route.

The Application will not provide the user with fashon advice.

# MVP
The Web Developer can send a color to an endpoint and receive a color palette.

The Web Developer can send multiple colors to and endpoint and receive verification on whether or not the colors belong to a palette.

MVP for the web application will have a landing page, a search for colors page, aand a page that shows the saved color schemes of the person.

There will be one database with two tables.

The database will have full CRUD functionality for both tables.

# Stretch

 Take in hex color codes.
 
 Return hex color codes.
 
 Implementation of color formula to add colors dynamically.
 
 Image processing.
 
 Return image examples.
 
 Create endpoints for specific categories of color usage.

Add a outfits page.

Add a outfits table in the database with Full CRUD functionality.

Give the user an option to submit a image of a color in the place of a string.

Amazon product search functionality.

# Functional Requirements

The Web Developer can send requests to an endpoint and receive a palette.

The Web Developer can send requests to an endpoint and receive a boolean response.

The user can search 

The user can create, edit and delete 

# MVC Non-Functional Requirements

The palette tables are connected

Application will have usability: easy to read font size and colors, consistent layout colors, error tolerant, quick and easy navigation, compatible for mobile.

Application will be testable: consistent, quantitative, and unambiguous.

# Data Flow

The Web Developer sends color/s to an endpoint and receives a JSON object.

When the user hit the home page there will be 2 links one for pets and one for the individual.  Once the user clicks the link, they will be redirected to their saved color scheme page, there will be seperate saved paged for pets and people. If there are saved results, the user can update or delete their saved color schemes.  Otherwise the user can go to the search page and search for a color harmony and save if they like the color scheme.


