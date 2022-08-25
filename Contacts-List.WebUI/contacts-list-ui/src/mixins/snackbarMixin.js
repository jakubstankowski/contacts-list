export const snackbarMixin = {
  data: () => ({
    snackbar: {
      status: false,
      message: null,
      color: null,
    },
  }),
  methods: {
    showAndHiddenSnackbar(snackbar) {
      this.snackbar = {
        status: snackbar.status,
        message: snackbar.message,
        color: snackbar.color,
      };
      setTimeout(() => {
        this.snackbar = {
          status: false,
          message: "",
          color: "",
        };
      }, 2000);
    },
  },
};
