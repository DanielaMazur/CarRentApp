import React from "react";
import { Snackbar as MUISnackbar } from "@material-ui/core";
import { Alert, Color } from "@material-ui/lab";

export type SnackbarProps = {
  status: Color;
  message: string;
};

const Snackbar: React.FC<SnackbarProps> = (props) => {
  return (
    <MUISnackbar open>
      <Alert elevation={6} variant="filled" severity={props.status}>
        {props.message}
      </Alert>
    </MUISnackbar>
  );
};

export { Snackbar };
