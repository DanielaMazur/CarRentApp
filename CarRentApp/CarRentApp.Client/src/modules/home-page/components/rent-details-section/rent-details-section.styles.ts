import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  rentCarStepsSection: {
    maxWidth: "1000px",
    margin: "20px auto",
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
}));

export { useStyles };
