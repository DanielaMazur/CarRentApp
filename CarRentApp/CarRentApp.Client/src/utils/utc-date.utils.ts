const getUtcDate = (date: Date) =>
  new Date(
    date.getTime() - new Date().getTimezoneOffset() * 60000
  ).toISOString();

export { getUtcDate };
