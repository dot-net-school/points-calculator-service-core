# Australian Immigration Institute - Point Calculation Service

## Introduction

This project is part of the Australian Immigration Institute's services. It's a point calculation service that helps applicants calculate their immigration points based on various factors such as age, work experience, education, and more. This project is an open-source initiative by the .NET School Community.


#OurTeam
## Our Perfect Mentor
- <a href="https://github.com/mohammadKarimi" target="_blank">@mohammadKarimi</a>

## Members
- <a href="https://github.com/FarzanehMG" target="_blank">@FarzanehMG</a>
- <a href="https://github.com/MohadeseEntezari" target="_blank">@MohadeseEntezari</a>
- <a href="https://github.com/mahdignb" target="_blank">@mahdignb</a>
- <a href="https://github.com/MehranLabour" target="_blank">@MehranLabour</a>

## Architecture

This project follows the principles of Lean Architecture. This approach focuses on delivering value to the end user while minimizing waste and maximizing efficiency.

## Services

Our point calculation service includes several sub-services:

- **Age Calculation**: Calculates points based on the applicant's age.
- **Work Experience Calculation**: Calculates points based on the applicant's work experience.
- **Education Calculation**: Calculates points based on the applicant's educational qualifications.

(Add more services as needed)

## Getting Started

### Prerequisites

We have Mock Server, Please Download <a href="https://mockoon.com/" target="_blank">Mockoon</a> and create an get api on it by route of "getcustomer/:id" after that put below json on it.

we need this mock platform to get sample customer info for calculate its scores

Sample Json :
```
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "age": 35,
  "marital": {
    "status": "1",
    "spousestatus": 2
  },
  "universitydegrees": [
    {
      "id": "bf37c607-e83f-474a-2943-08dbec01c069",
      "universityname": "PGU ",
      "degreename": "Computer engineer - Bachelor"
    },
    {
      "id": "395863d8-0dfd-4975-2944-08dbec01c069",
      "name": "Azad ALi Shahr",
      "degreename": "Computer Engineer - Associate"
    }
  ],
  "languagedegrees": [
    {
      "id": "dfd00566-3ff3-4855-e316-08dbebfe276c",
      "name": "Ielts",
      "mark": "8"
    },
    {
      "id": "98eac0b9-d56e-4b72-e31a-08dbebfe276c",
      "name": "PTE 65",
      "mark": "65"
    }
  ],
  "jobexperience": 10
}
```

For test TotalScore Calculator You need to run Mock Server

### Installation

(Provide step-by-step instructions on how to set up and install your project locally)

## Usage

(Explain how to use your project. Provide examples or use cases)

## Contributing

We welcome contributions from the community. If you're interested in contributing, please see our CONTRIBUTING.md file for guidelines.

## License

This project is free to use under the (insert license here) license.

## Contact

If you have any questions or suggestions, please contact us at (insert contact information here).
