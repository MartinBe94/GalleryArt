import { Dashboard } from "./components/Dashboard";
import { FetchData } from "./components/FetchData";
import { Gallery } from "./components/Gallery";
import { Home } from "./components/Home";
import { SignUp } from "./components/SignUp";
import { TopList } from "./components/TopList";


const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/Gallery',
    element: <Gallery />
  },
  {
    path: '/TopList',
    element: <TopList />
  },
  {
    path: '/FetchData',
    element: <FetchData />
  },
  {
    path: '/Dashboard',
    element: <Dashboard />
  },
  {
    path: '/SignUp',
    element: <SignUp />
  }
];

export default AppRoutes;
