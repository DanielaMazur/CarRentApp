import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  cancelButton: {
    color: theme.palette.error.dark,
    border: "1px solid",
    borderColor: theme.palette.error.dark,
    "&:hover": {
      boxShadow: "none",
    },
    "&:active": {
      boxShadow: "none",
    },
    "&:focus": {
      boxShadow: "0 0 0 0.2rem rgba(0,123,255,.5)",
    },
  },
  signInButton: {
    color: "white",
  },
}));

export { useStyles };
