import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@material-ui/core";

import { RentCarForm } from "./rent-car-form";

export type RentCarModalProps = {
  carPrice: number;
  isOpen: boolean;

  handleClose: () => void;
  handleConfirm: (formValues: any) => void;
};

const RentCarModal = (props: RentCarModalProps) => {
  return (
    <>
      <Dialog
        open={props.isOpen}
        onClose={props.handleClose}
        aria-labelledby="rent-dialog-title"
      >
        <DialogTitle id="rent-dialog-title">Rent</DialogTitle>

        <DialogContent>
          <DialogContentText>
            Choose an appropriate date range to make a reservation
          </DialogContentText>
          <RentCarForm
            carPrice={props.carPrice}
            handleFormSubmit={props.handleConfirm}
          />
        </DialogContent>

        <DialogActions>
          <Button onClick={props.handleClose} color="primary">
            Cancel
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export { RentCarModal };
