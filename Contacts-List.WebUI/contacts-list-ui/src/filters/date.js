import moment from "moment";
moment.locale("pl");

export default (value) => {
  if (value) {
    return moment(String(value)).format("L");
  }
};
