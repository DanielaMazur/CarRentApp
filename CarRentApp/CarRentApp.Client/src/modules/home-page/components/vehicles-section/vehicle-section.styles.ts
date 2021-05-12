import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles(() => ({
  sectionTitle: {
    textAlign: "center",
    fontWeight: "bold",
    margin: "30px 0",
  },
  chooseCarSection: {
    alignSelf: "center",
  },
  carTypeContainer: {
    cursor: "pointer",
    display: "flex",
    flexDirection: "column",
    height: "100%",
    borderRadius: "10px",
    filter: " grayscale(100%)",

    "&:hover": {
      filter: " grayscale(0%)",
    },
  },
  carImage: {
    width: "100%",
    marginTop: "auto",
  },
  carName: {
    textAlign: "center",
  },
  showAllCarsButton: {
    margin: "15px auto 30px auto",
    color: "white",
  },
}));

export { useStyles };
