const getReservationPrice = (
  startDate: Date,
  endDate: Date,
  pricePerDay: number
) => {
  const differenceInTime = endDate.getTime() - startDate.getTime();

  const differenceInDays = differenceInTime / (1000 * 3600 * 24);

  return pricePerDay * differenceInDays;
};

export { getReservationPrice };
