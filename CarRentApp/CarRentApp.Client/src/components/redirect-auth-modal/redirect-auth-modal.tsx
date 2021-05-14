import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Button,
} from "@material-ui/core";
import { useHistory } from "react-router";

import { useStyles } from "./redirect-auth-modal.styles";

export type RedirectAuthModalProps = {
  isOpen: boolean;
  handleClose: () => void;
};

const RedirectAuthModal = (props: RedirectAuthModalProps) => {
  const classes = useStyles();
  const history = useHistory();

  return (
    <Dialog
      open={props.isOpen}
      onClose={props.handleClose}
      aria-labelledby="redirect-auth-dialog"
    >
      <DialogTitle id="redirect-auth-dialog-title">
        You cannot make a reservation yet
      </DialogTitle>

      <DialogContent>
        <DialogContentText>
          Please sign in into your Carrent account to make a reservation
        </DialogContentText>
      </DialogContent>

      <DialogActions>
        <Button
          className={classes.signInButton}
          color="primary"
          variant="contained"
          onClick={() => history.push("/sign-in")}
        >
          Sign In
        </Button>

        <Button
          onClick={() => history.push("/sign-up")}
          color="secondary"
          variant="contained"
        >
          Sign Up
        </Button>

        <Button onClick={props.handleClose} className={classes.cancelButton}>
          Cancel
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export { RedirectAuthModal };
