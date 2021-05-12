const stringToColour = (str: string) => {
  let hash = 0;

  for (let i = 0; i < str.length; i++) {
    hash = str.charCodeAt(i) + ((hash << 5) - hash);
  }

  let colour = "#";
  for (var i = 0; i < 3; i++) {
    const value = (hash >> (i * 6)) & 0xff;

    colour += ("00" + value.toString(16)).substr(-2);
  }

  return colour;
};

export { stringToColour };
