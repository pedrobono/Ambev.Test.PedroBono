﻿using Ambev.Test.PedroBono.WebApi.Feature.Carts.CreateCartProduct;

namespace Ambev.Test.PedroBono.WebApi.Feature.Carts.GetCart
{
    /// <summary>
    /// Represents the response returned after get a shopping cart.
    /// </summary>
    public class GetCartResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Cart.
        /// </summary>
        /// <value>A Id that uniquely identifies the created product in the system.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who owns the cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart was created or the desired date for the cart.
        /// </summary>
        /// <value>The date in the format "DD/MM/YYYY".</value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the list of products associated with the cart.
        /// </summary>
        public List<CreateCartProductResponse> Products { get; set; }


    }
}
