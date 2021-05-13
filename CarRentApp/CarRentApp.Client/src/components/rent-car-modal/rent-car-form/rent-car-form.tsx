import { useState } from "react";
import { useForm, Controller } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { DateRange, OnChangeProps } from "react-date-range";
import "react-date-range/dist/styles.css";
import "react-date-range/dist/theme/default.css";
import { Button, Typography } from "@material-ui/core";

import { getReservationPrice } from "utils/reservation-price.utils";

import { Reservation } from "types";

import { useStyles } from "./rent-car-form.styles";

const RentCarFormSchema = yup.object().shape({
  rangeDate: yup.object({
    startDate: yup.date().required(),
    endDate: yup.date().required(),
  }),
});

export type RentCarFormProps = {
  carPrice: number;
  handleFormSubmit: (formValues: Reservation.ReservationForm) => void;
};

const RentCarForm = (props: RentCarFormProps) => {
  const classes = useStyles();
  const [totalPrice, setTotalPrice] = useState(0);

  const { handleSubmit, control } = useForm({
    resolver: yupResolver(RentCarFormSchema),
    defaultValues: {
      rangeDate: {
        startDate: new Date(),
        endDate: new Date(),
      },
    },
  });

  const handleDatePickerChange = (
    item: OnChangeProps,
    onChange: (...event: any[]) => void
  ) => {
    const {
      range1: { startDate, endDate },
    } = item as any;

    const newRange = {
      startDate,
      endDate,
    };

    setTotalPrice(
      getReservationPrice(newRange.startDate, newRange.endDate, props.carPrice)
    );

    onChange(newRange);
  };

  const onSubmit = (formValues: { rangeDate: Reservation.ReservationForm }) => {
    const reservationRange = formValues.rangeDate;

    props.handleFormSubmit(reservationRange);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className={classes.form}>
      <Controller
        name="rangeDate"
        control={control}
        render={({ field: { onChange, value } }) => (
          <DateRange
            className={classes.dateRange}
            onChange={(item) => handleDatePickerChange(item, onChange)}
            ranges={[value]}
          />
        )}
      />

      <Typography variant="h5" className={classes.totalPrice}>
        Rental Price: {totalPrice}
      </Typography>

      <Button type="submit" fullWidth variant="contained" color="primary">
        Add Reservation
      </Button>
    </form>
  );
};

export { RentCarForm };
