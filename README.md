# relationships Betweens Table

1.Product and Category: -->many-to-one relationship, as multiple products can belong to the same category, but each product typically belongs to only one category. (category_id column added in Product Table )

2.Order and User: -->many-to-one relationship, as multiple orders can be associated with a single user (customer). However, a single order typically belongs to only one user. (user_id column added in Order Table )

3.User and Order: -->one-to-many relationship. Each user can have multiple orders, but each order belongs to only one user. (user_id column added in Order Table )

4.User and addChart: -->one-to-many relationship. Each user can have multiple items in their cart, but each item in the cart belongs to only one user. (user_id column added in addcharT Table )

5.Order History and Order: Many-to-one relationship (order_id column added in OrderHistory Table )

6.Order History to User Relationship: Many-to-one relationship. (user_id column added in OrderHistory Table )

7.ProductsOrders: Many To Many Relationships
