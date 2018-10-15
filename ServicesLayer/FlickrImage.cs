using System;
using System.Collections.Generic;
using System.Text;
using FlickrNet;

namespace SL
{
    public class FlickrImage
    {
        protected Flickr flickr = new Flickr("83cc1aee4120c6a991b6512f00c98081", "36d6fd2b7932e3e5");
        
        public void SearchImage (string searchTerms)
        {
            var searchoptions = new PhotoSearchOptions();
            searchoptions.Text = searchTerms
            flickr.PhotosSearch(PhotoSearchOptions)
        }
    }
}
