export default {
  parse(error) {
    console.log("error", error);
    if (error.response) {
      const status = error.response.status;
      const message = error.response.message;

      switch (status) {
        case 401: {
          return new Error("Request not authorized");
        }
        case 404: {
          return new Error(
            "Request failed. Request endpoint not found on the server"
          );
        }
        case 500: {
          return new Error(
            "This is rephrased error message. Please try again later"
          );
        }
        default: {
          return new Error(message);
        }
      }
    }
  },
};
