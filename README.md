# BlueBadgeFinal
# BlueBadgeFinal
Thank you to Adam/Terry for grading and reading this!
Miro Board Link  https://miro.com/app/board/o9J_lJem-yM=/

The goal of this project is to create an application that would be used by a staff member of a gym (we named the gym AverageJoes [please get the Dodgeball reference]) to create Memberships for people as well as input personal information for a User. We also have Activities that can be posted and signed up for (i.e yoga, spin class).

To start the project we selected Kaitlynn as the git master and she laid out the scaffolding of the project(MVC) and got it all pushed to Git for Jerome and Myself to pull onto our PCs. 

(Jerome)
Memberships 

The Membership Class consists of a few properties. An Enum that declares a few types of Memberships you could have to the gym, an ID, a DateTime for when created and a DateTime for when modified along with the ability to input Notes(i.e this Membership belongs to someone with a peanut allergy or this person is a Senior Citizen and gets a possible discount). 

The MembershipType property consists of 5 different types of Memberships: Annual, SemiAnnual, Quarterly,Monthly, Weekly with a corresponding number linked to each one. The index is set to start at Annual =1 and then go up to 5 in the order it’s shown. Each Membership has an ID and can have 1 User or multiple Users in the case that it is a family Membership.   

MembershipModels:
1. MembershipCreate: Creates the Membership. Used in CreateMemberships in the MembershipServices. Requires the Type of Membership and has the Notes property *Not required but Max length of 8000*. 

2. MembershipDetail:  Used in GetMembershipsbyID in the MembershipServices to display all of the information about a specific Membership ID that the worker would need to know(i.e ID, Type, Notes, DateTime Created and DateTime Modified) Useful if a staff member needs to see further detail about a certain Membership.

3. MembershipEdit: 
Used in UpdateMembership in the MembershipServices to update information of a Membership. Specifically the membership type and notes. 


4. MembershipListItem:
Used in GetMemberships in the MembershipServices to to display all of the information about all Memberships that the worker would need to know(i.e ID, Type, Notes, DateTime Created and DateTime Modified) Useful if a staff member needs to see further detail of all Memberships.



MembershipServices EndPoints:
1. CreateMembership: 

Used to create a new membership. Create membership Id, membership type, date created, and any notes about the membership.

2. GetMemberships:

Used to get all memberships and display membership ID, membership type, date created, and any notes about the membership. 

3. GetMembershipsByID:

Used to get a specific membership by ID. It will also display membership ID, membership type, date created, and any notes about the membership. It will also display the modified date. 

4. UpdateMembership:

Used to update a membership by membership by ID. You won’t need to put an ID in the URI. You will need to post it as a key in postman. It will allow you to update  membership type, notes about the membership, and date modified. 


5. DeleteMembership:

Used to delete membership by membershipID. 

*Note: We had a slight naming convention problem due to the folders in the Models portion of our solution, so that is why the naming of the class in the solution explorer(Membership) is slightly different than the name of the class(Memberships). We apologize for any confusion*


(Michael)
Users (Customers at the gym)

The Users class consists of an ID(Key), a Guid, and then some basic contact information about a person that would be needed like Address, Name, PhoneNumber, Email and CreditCard(I made it a long instead of doing the formatting for the PhoneNumber so it could have dashes and parentheses, this was mainly due to time constraint. The User class also contains an ICollection<Enrollments> that is used to link User to the Enrollment class which acts as the "joining table" for the User and Activity classes.  

User Models:

1. UserCreate- Creates the User. Requires the worker to input the personal information of the User (Name, Address, PhoneNumber, Email, and CreditCard) along with the way the Membership is paid for(Annual, SemiAnnual, Quarterly, Monthly, or Weekly) *All fields are required*

2. UserDetail - Used in the UserServices to display all of the personal information of the user when called upon with the GetUserByID method. Useful for when the staff worker would like to select a single User to review their personal information and decide if changes are needed. This is also a way to see what Activity a user is signed up for because it contains an ICollection for ActivityListItem. 

3. UserEdit - Allows the worker to edit the users information so incase they have any changes to their contact information. *No fields are required but in postman they must at least be checked. For example, an unchecked Email field will result in a BadRequest response. 

4. UserListItem - This is used in the UserServices to display just the Name and ID of the User. This is used when an Activity is called on to see who is signed up for that Activity. No personal information is displayed for privacy reasons. 

UserServicesEndpoints: 

1. CreateUser - Takes in the UserCreate model in the parameters. Requires the Name, Address, PhoneNumber, Email, and CreditCard along with the MembershipID. *Must either join an existing Membership that has been made for family or friends, or the staff member must first make a new Membership before creating the user in order to assign them to a Membership*

2. GetUserByID - Takes in an int id and uses that to search for a user by their specific ID. This will display with UserDetail all of a Users personal information as well as their Membership and any Activity that they are signed up for.

3. UpdateUsers - This endpoint allows the worker to edit any of the personal information of a User along with enrolling them into any Activity that is available. *No fields are required but in postman they must at least be checked. For example, an unchecked Email field will result in a BadRequest response. *

4. GetUsers -  This endpoint will just use the UserListItem model to show all active Users in the database. Displays their ID, MembershipID, MembershipType, and Name. *No personal information is displayed, you would use this to see the ID so that you can use the GetByID method to see a Users personal information.*

5. DeleteUsers - This endpoint will take in an int ID in order to select a specific User and delete them from the database. *Would recommend using the GetUsers method in order to see what ID is needed*

 
*Note: We had a slight naming convention problem due to the folders in the Models portion of our solution, So that is why the naming of the class in the solution explorer(User) is slightly different than the name of the class(Users) We apologize for any confusion*

(Kaitlynn)
Activities 

The Activity Class is so the staff member at the "Gym" is able to create activities like yoga class or a cycling class. The goal is a many-to-many relationship so that we can have a User with many Activities or an Activity with many Users. The many-to-many relationship of User and Activity are being joined by the Enrollment table. The class consists of an ID(Key), Name, Description, Guid, and an ICollection<Enrollment> Enrollments. 

Activity Models:

1. ActivityCreate: Creates an Activity. Used in CreateActivity in the ActivityServices. Has the properties of ID, Name, and Description *No fields required* Allows the worker to input the Name and Description of an Activity at the Gym so that Users can sign up for it if they would like.

2. ActivityDetail: Used in the ActivityServices to display all of the information about an Activity when called upon with the GetActivityByID method. Useful for when the staff worker would like to select a single Activity to look at the Name and Description. This is  a useful way to see what Activity a user is signed up for because it also contains an ICollection for UserListItem. 

3. ActivityEdit:  Used in the ActivityServices to Edit the information of an activity when called upon by the ActivityEdit method. Useful for when an instructor has updates to make to their class. 

4. ActivityListItem: Used in the ActivityServices to display the Activity information with the GetActivites method. Useful for the staff member to see all of the Activities posted by all  instructors at the Gym and then use that to see if there are any changes or edits needed to be made. 

ActivityServicesEndpoints:

1. CreateActivity: Takes in the ActivityCreate model in the parameters. Asks for the Name and Description. *No fields required*

2. GetActivities: Uses ActivityListItem to display all Activities. Displays the ID, Name, and Description.

3. GetActivitiesByID: Uses ActivityDetail and takes in an int id. It will then use the List<UserListItem> and set it equal to a new UserListItem. Then uses a foreach loop to search through Enrollments. Then uses ActivityDetail to display the ID, Name, Description, and then all Users signed up. 

4. UpdateActivities:  Uses the ActivityEdit model to allow the worker to change any information about an Activity. *Must change at least something in the fields or it will not work. All fields must be checked as well even if nothing has changed*

5. DeleteActivity: Takes in an int id and allows the staff member to use the ID of a customer so that they can remove them from the database. *Would recommend using the GetActivity method to see the ID of the Activities*




(Everyone)
Enrollment
The Enrollment class is our joining table to connect User and Activity so that we can have multiple Users be a part of an Activity at the gym as well as multiple Activities being a part of 1 User. This was a stretch goal. The Enrollment Class consists of an ID (Key) and 2 Foreign Keys. 1 for UserID and 1 for ActivityID. We struggled through this portion and it was difficult to grasp at the beginning. After lots of google and a help from Seth and Sean we were able to get it working. Once we could use it in postman it started to make more sense to us all. The endpoint of Enrollment is just to Post. The real use of it is so when we display a user by their ID we can see what Activities they have decided they want to sign up for and attend. 
