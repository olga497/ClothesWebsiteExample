# ClothesWebsiteExample

The clothes website initial development part consists of:

**Backend (C\# and .NET)**:
The backend is developed using C\# and the .NET framework. It serves as the server-side component of the web application, handling user authentication and authorization, product management, and interaction with the MySQL database.

**Frontend (React JS)**:
The frontend is developed using React JS. It provides the user interface; users can register, log in, view a list of products, and submit new product listings. It communicates with the backend through API requests to fetch and display data, as well as to send user actions, such as registration and product submissions.

**MySQL database**:
The database is used for storage of user registration data (with password encrypted), a list of products (which is being updated as new products are added), and a list of categories that are created when the code is run for the first time and can be dynamically updated by users.

## Running on Docker:
Docker should be installed and running. 
Go to **Assignment3** folder in the CLI and use `docker-compose up -d` for running the application in the background. The images will be built if there are no images from before and containers for backend, frontend and database will be created. 

Depending on where you run an application, you should change environment variable in the frontend folder in the **.env** file for the IP address (**public IP address** for AWS EC2 instance, **localhost** for the local machine).

