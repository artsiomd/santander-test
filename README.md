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

You can then run the **RestAPI** and **Worker** applications independently. The **RestAPI** supports **OpenAPI**, and its documentation is available at [`/openapi/v1.json`](./openapi/v1.json). Additionally, it automatically launches **Scalar UI** for running queries.

---

# 📌 Enhancements to Consider

### 🔐 Security
- The application currently uses a **self-signed certificate**.
- No **secret management** is implemented.
- **Redis and other services are not properly secured**.
- **No authentication** mechanism is in place.

### 📊 Logging & Monitoring
- The application lacks proper **logging**.
- Logs are **not stored** in tools like **Datadog** or **Prometheus**.
- No **metrics collection**.
- No **monitoring tools** or **alerting mechanisms**.

### 📖 Documentation
- **Insufficient API documentation** (basic OpenAPI support is available but limited).
- The **README file** needs improvements.

### ⚙️ Configuration
- Many parameters are **hardcoded** as **magic numbers/strings**.
- Should be configurable via **environment variables** or **configuration files**.

### 🧪 Automated Testing
- No **unit tests**.
- No **integration tests**.
- No **end-to-end (e2e) tests**.

### 🚀 And More...
- There are various areas that require improvement to enhance the **security, scalability, and maintainability** of the project.
