# 📌 Task Description

Using **ASP.NET Core**, implement a **RESTful API** to retrieve the details of the first **n "best stories"** from the **Hacker News API**, where **n** is specified by the caller.

### 🔗 Hacker News API Documentation
- [Hacker News API](https://github.com/HackerNews/API)
- **Best Stories Endpoint:** [`https://hacker-news.firebaseio.com/v0/beststories.json`](https://hacker-news.firebaseio.com/v0/beststories.json)
- **Story Details Endpoint:** [`https://hacker-news.firebaseio.com/v0/item/{storyId}.json`](https://hacker-news.firebaseio.com/v0/item/21233041.json) (example for story ID **21233041**)

### 📜 API Requirements
- The API should return an array of the first **n "best stories"**, sorted by **score in descending order**.
- Response format:
  ```json
  [
    {
      "title": "A uBlock Origin update was rejected from the Chrome Web Store",
      "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
      "postedBy": "ismaildonmez",
      "time": "2019-10-12T13:43:01+00:00",
      "score": 1716,
      "commentCount": 572
    },
    { ... },
    { ... },
    { ... }
  ]
  ```
- The API must efficiently handle **large numbers of requests** without overloading the Hacker News API.
- A **public repository** should be shared, including a `README.md` file detailing how to run the application, assumptions made, and any planned enhancements or improvements.

---

# 📌 Assumptions

The entire implementation was driven by **assumptions**. Any hardcoded value was taken from the top of my head without deep investigation. In a real-world scenario, all **functional and non-functional requirements** should be properly discussed and agreed upon before implementation.

---

# 🚀 Getting Started

To run this application, you need to have **Docker Compose** installed.

## Running the Environment for Testing

To spin up the entire environment:

1. Navigate to the repository's root folder.
2. Run the following command:
   ```sh
   docker-compose up -d
   ```

This will start all required services. The API listens for requests on standard ports **80/443**. You can use a browser or tools like **Postman** to interact with the API.

> **Note:** If you have other services running on these ports, conflicts may occur.

📜 **API Documentation:** Available at [`/openapi/v1.json`](./openapi/v1.json).

---

## Debugging

For debugging purposes, you may want to run only Redis and expose its standard port to the host:

1. Navigate to the repository's root folder.
2. Run:
   ```sh
   docker-compose -f docker-compose.yml -f docker-compose.dev.yml up redis -d
   ```

This will run **only Redis**.

You can then run the **RestAPI** and **Worker** applications independently using http launch profile. The **RestAPI** supports **OpenAPI**, and its documentation is available at [`/openapi/v1.json`](./openapi/v1.json). Additionally, it automatically launches **Scalar UI** for running queries.

---

# 📌 Enhancements to Consider

### 🔐 Security
- The application currently uses a **self-signed certificate**.
- No **secret management** is implemented.
- **Redis and other services are not properly secured**.
- **No authentication** mechanism is in place.

### 📊 Logging & Monitoring
- The application lacks proper **logging**.
- Logs are **not exported** any storage.
- No **metrics collection**.
- No **monitoring tools** or **alerting mechanisms**.

### 📖 Documentation
- **Insufficient API documentation** (basic OpenAPI support is available but limited).
- The **README file** you read now needs improvements.

### ⚙️ Configuration
- Many parameters are **hardcoded** as **magic numbers/strings**.
- Should be configurable via **environment variables** or **configuration files**.

### 🧪 Automated Testing
- No **unit tests**.
- No **integration tests**.
- No **end-to-end (e2e) tests**.

### 🚀 And More...
- There are various areas that require improvement to enhance the **security, scalability, and maintainability** of the project.
