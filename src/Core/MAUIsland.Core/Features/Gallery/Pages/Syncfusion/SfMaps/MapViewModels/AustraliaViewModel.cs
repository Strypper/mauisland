#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace MAUIsland.Core;
public class AustraliaViewModel
{
    public ObservableCollection<AustraliaModel> Data { get; set; }

    public AustraliaViewModel()
    {
        Data = new ObservableCollection<AustraliaModel>()
            {
                new AustraliaModel("New South Wales",5),
                new AustraliaModel("Queensland",23),
                new AustraliaModel("Northern Territory",56),
                new AustraliaModel("Victoria",16),
                new AustraliaModel("Western Australia",43),
                new AustraliaModel("South Australia",26)
           };
    }
}
