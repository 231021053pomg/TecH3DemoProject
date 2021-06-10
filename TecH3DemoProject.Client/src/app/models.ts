export interface Author {
  id: number;
  firstName: string;
  lastName: string;
  books?: Array<Book>;
}

export interface Book {
  id: number;
  title: string;
  published: Date;
  authorId: number;
  pages: number;
}


export interface User{
  email: string;
  password:string;
}