export type Publisher = {
  publisherName : string;
  publisherId : string;
  state : string;
  country : string;
}

export type UpdatePublisher = {
  name : string;
  city : string;
  state : string;
  country : string;
}