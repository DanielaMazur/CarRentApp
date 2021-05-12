import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  rentCarStepsSection: {
    margin: "20px 0",
  },
  rentDetailsContainer: {
    [theme.breakpoints.down("xs")]: {
      order: 2,
    },
  },
  stepContainer: {
    borderRadius: "50%",
    padding: "10px 18px",
    backgroundColor: theme.palette.primary.main,
    justifyContent: "center",
    alignItems: "center",
    display: "flex",
    color: "white",
    fontWeight: 900,
    fontSize: "20px",
    marginRight: "20px",
  },
  rentStepTitleContainer: {
    display: "flex",
    alignItems: "center",
    marginBottom: "15px",
    marginTop: "25px",
  },
  rentImage: {
    maxHeight: "520px",
    width: "100%",
    margin: "auto",
  },
}));

export { useStyles };
