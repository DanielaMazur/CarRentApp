import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  paper: {
    padding: "6px 16px",
  },
  secondaryTail: {
    backgroundColor: theme.palette.secondary.main,
  },
  timeLineItem: {
    [theme.breakpoints.down("xs")]: {
      "&::before": {
        flex: 0,
      },
    },
  },
}));

export { useStyles };
