export interface AnimeCardInterface {
  id: number;
  titleEN: string;
  titleJP: string;
  studioId: number;
  studioName: string;
  shortDescription: string;
  description: string;
  imageUrl: string;
  genreId: number;
  genreName: string;
  releaseDate: string;
  airedStart: string;
  airedEnd: string;
  rating: number;
  episodes: number;
  animeTypeId: number;
  animeTypeName: string;
  animeStatusId: number;
  animeStatusName: string;
}

