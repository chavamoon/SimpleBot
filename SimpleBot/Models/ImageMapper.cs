﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBot.Models
{
    public class ImageMapper
    {
        public static SearchHit ToSearchHit(dynamic hit)
        {
            var searchHit = new SearchHit
            {
                Key = (string)hit.Document["rid"],
                Title = (string)hit.Document["FileName"],
                PictureUrl = (string)hit.Document["BlobUri"],
                Description = (string)hit.Document["Caption"]
            };

            object Tags;
            if (hit.Document.TryGetValue("Tags", out Tags))
            {
                searchHit.PropertyBag.Add("Tags", Tags);
            }
            return searchHit;
        }

    }
}
