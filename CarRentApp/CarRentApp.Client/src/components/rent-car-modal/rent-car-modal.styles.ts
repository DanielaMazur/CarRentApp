import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  cancelButton: {
    backgroundColor: theme.palette.error.dark,
    color: "white",
    "&:hover": {
      backgroundColor: theme.palette.error.light,
      borderColor: theme.palette.error.light,
      boxShadow: "none",
    },
    "&:active": {
      backgroundColor: theme.palette.error.light,
      borderColor: theme.palette.error.light,
      boxShadow: "none",
    },
    "&:focus": {
      boxShadow: "0 0 0 0.2rem rgba(0,123,255,.5)",
    },
  },
}));

export { useStyles };
