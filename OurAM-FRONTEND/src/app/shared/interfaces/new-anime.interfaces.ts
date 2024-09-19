export interface GenericLookupInterface {
  id: number;
  name: string;
}

export interface AnimeLookupInterface {
  genres: GenericLookupInterface[];
  studios: GenericLookupInterface[];
  animeTypes: GenericLookupInterface[];
  animeStatuses: GenericLookupInterface[];
}
