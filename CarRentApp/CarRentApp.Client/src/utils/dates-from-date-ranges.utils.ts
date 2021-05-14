import { Reservation } from "types";

const getDatesFromDateRanges = (
  disabledRanges: Reservation.ReservedDayRanges
) => {
  const disabledDates = [];

  for (const range of disabledRanges) {
    const [startDateString, endDateString] = range;

    const startDate = new Date(startDateString);
    const endDate = new Date(endDateString);

    const differenceInTime = endDate.getTime() - startDate.getTime();

    const millisecondsPerDay = 1000 * 3600 * 24;

    const differenceInDays = differenceInTime / millisecondsPerDay;

    for (let i = 0; i <= differenceInDays; i++) {
      const dateMilliseconds = startDate.getTime() + millisecondsPerDay * i;

      disabledDates.push(new Date(dateMilliseconds));
    }
  }

  return disabledDates;
};

export { getDatesFromDateRanges };
