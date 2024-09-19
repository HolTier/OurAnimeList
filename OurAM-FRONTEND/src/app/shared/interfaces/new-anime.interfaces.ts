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

export interface NewAnimeInterface {
  titleEN: string;
  titleJP: string;
  studioID: number;
  shortDescription: string;
  description: string;
  imageUrl: string;
  genreID: number;
  ReleaseDate: Date;
  AiredStart: Date;
  AiredEnd: Date;
  episodes: number;
  rating: number;
  animeTypeID: number;
  animeStatusID: number;
}
