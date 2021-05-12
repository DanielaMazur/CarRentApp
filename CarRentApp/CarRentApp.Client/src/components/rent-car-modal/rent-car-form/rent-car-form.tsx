import { useState } from "react";
import { useForm, Controller } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { DateRange, OnChangeProps } from "react-date-range";
import "react-date-range/dist/styles.css";
import "react-date-range/dist/theme/default.css";
import { Button, Typography } from "@material-ui/core";

import { useStyles } from "./rent-car-form.styles";

const RentCarFormSchema = yup.object().shape({
  rangeDate: yup.object({
    startDate: yup.array().of(yup.date().required()),
    endDate: yup.array().of(yup.date().required()),
  }),
});

export type RentCarFormProps = {
  carPrice: number;
  handleFormSubmit: (formValues: any) => void;
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

    const differenceInTime =
      newRange.endDate.getTime() - newRange.startDate.getTime();
    const differenceInDays = differenceInTime / (1000 * 3600 * 24);

    setTotalPrice(props.carPrice * differenceInDays);

    onChange(newRange);
  };

  return (
    <form onSubmit={handleSubmit(props.handleFormSubmit)}>
      <Controller
        name="rangeDate"
        control={control}
        render={({ field: { onChange, value } }) => (
          <DateRange
            onChange={(item) => handleDatePickerChange(item, onChange)}
            editableDateInputs={true}
            moveRangeOnFirstSelection={false}
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
