## Table of contents
1. [Overview](ReadMe.md)
1. [Setup](docs/Setup.md)
1. [Vision](docs/Vision.md)
1. **[Coding exercise](docs/Exercise.md)**

# Sales Taxes 

### Goal
The goal of this exercise is to create a tax calculation library which satisfies the business rules described below.   
The solution should be easily extensible to accommodate new tax rules, for example to support multiple regions and/or countries.

### Business Rules
The following are the main business rules of this coding exercise.

1. When I purchase items, I receive a receipt which lists the names of all the items and their prices (including tax). It also includes the total price of the items and the total amount of sales taxes paid.
2. Basic sales tax is applicable at a rate of 10% on all goods **except**:
  - Food
  - Book
  - Medical
3. Import duty is applicable at a rate of 5% on all imported goods, with no exemptions.
4. Tax should be rounded up to the nearest five cents for each item of the basket.

### Exercise
Create the tax calculation library, then use it to compute the tax for following three shopping baskets, outputting all receipt details as specified:

#### Sample data
```
Basket 1                 |  Basket 2                               |  Basket 3
1 book at 12.49          |  1 imported box of chocolates at 10.00  |  1 imported bottle of perfume at 27.99
1 music CD at 14.99      |  1 imported bottle of perfume at 47.50  |  1 bottle of perfume at 18.99
1 chocolate bar at 0.85  |                                         |  1 packet of headache pills at 9.75
                         |                                         |  1 imported box of chocolates at 11.25
```

#### Expected output
```
Receipt 1                |  Receipt 2                              |  Receipt 3
1 book: 12.49            |  1 imported box of chocolates: 10.50    |  1 imported bottle of perfume: 32.19
1 music CD: 16.49        |  1 imported bottle of perfume: 54.65    |  1 bottle of perfume: 20.89
1 chocolate bar: 0.85    |  Sales Taxes: 7.65                      |  1 packet of headache pills: 9.75
Sales Taxes: 1.50        |  Total: 65.15                           |  1 imported box of chocolates: 11.85
Total: 29.83             |                                         |  Sales Taxes: 6.70
                         |                                         |  Total: 74.68
```

### How you will be evaluated

We are interested in evaluating:

* Design: see if you can develop a well structured solution, with a flexible, extensible, and efficient design. You will be evaluated on both suitability and correctness. For example, if you choose a particular design pattern, we will consider both whether it's a good fit and whether it has been implemented correctly.
* Code quality: readability, maintainability, and consistency.
* Automated tests: unit testing is mandatory at least for the tax calculation library, and integration testing may be added at your discretion.

We are **not** interested in:

* UI: console or integration test(s) is fine to display expected output.
* Input mechanism: the end user is not supposed to enter any data.
* Data storage: you may hard code everything required, so please feel free to provide data directly in your code and/or tests.

### What you should deliver
Keep in mind we're looking for quality and attention to detail, not quantity.

You may use frameworks and/or tools that are in general usage for the target technology stack. However, we ask that the central problem of the coding exercise (the calculation of sales tax) be performed entirely by your own code. Furthermore running the program must **not** require any local configuration (database, etc.): just build then run.

For external libraries, please use NuGet exclusively and rely only on libraries available publicly (aka from NuGet.org).
