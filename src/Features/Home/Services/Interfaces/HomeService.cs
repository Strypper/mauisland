namespace MAUIsland;

public class HomeService : IHomeService
{
    public Task<IEnumerable<MAUIFact>> GetMAUIFactsAsync()
    {
        return Task.Run(() =>
        {
            var facts = new List<MAUIFact>();
            facts.Add(new MAUIFact()
            {
                Fact = "Maui is the second largest of the Hawaiian Islands",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#maui_is_the_second_largest_of_the_hawaiian_islands"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "One of the world’s largest dormant volcanoes is on Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#one_of_the_world%E2%80%99s_largest_dormant_volcanoes_is_on_maui"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "“Valley Isle” is Maui's nickname",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#%E2%80%9Cvalley_isle%E2%80%9D_is_maui's_nickname"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Maui has multiple pineapple farms",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#maui_has_multiple_pineapple_farms"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "There are only two volcanoes on Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#there_are_only_two_volcanoes_on_maui"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Approximately 10,000 humpback whales migrate to Maui each year",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#approximately_10,000_humpback_whales_migrate_to_maui_each_year"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "The Hana Highway includes 59 bridges and 620 curves",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#the_hana_highway_includes_59_bridges_and_620_curves"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "You can explore a sugar museum on Maui!",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#you_can_explore_a_sugar_museum_on_maui!"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Maui is home to the third largest population in Hawaii",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#maui_is_home_to_the_third_largest_population_in_hawaii"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Maui is home to the largest banyan tree in the US",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#maui_is_home_to_the_largest_banyan_tree_in_the_us"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "The title of best island in the US often goes to Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#the_title_of_best_island_in_the_us_often_goes_to_maui"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Captain James Cook was the first European to see Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#captain_james_cook_was_the_first_european_to_see_maui"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "At least five endangered marine species can be seen in Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#at_least_five_endangered_marine_species_can_be_seen_in_maui"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Molokini Crater is home to over 250 marine species",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#molokini_crater_is_home_to_over_250_marine_species"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Lahaina on Maui was once the capital of Hawaii",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#lahaina_on_maui_was_once_the_capital_of_hawaii"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "You can attend free town parties every Friday",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#you_can_attend_free_town_parties_every_friday"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "There are 120 miles of coastline and 30 miles of beaches in Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#there_are_120_miles_of_coastline_and_30_miles_of_beaches_in_maui"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Living in Maui could extend your life!",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#living_in_maui_could_extend_your_life!"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Lahaina High School is one of the US’ oldest schools",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#lahaina_high_school_is_one_of_the_us%E2%80%99_oldest_schools"
            });

            facts.Add(new MAUIFact()
            {
                Fact = "Black volcanic beaches can be found on Maui",
                FactUrl = "https://www.destguides.com/united-states/hawaii/maui/maui-hawaii-facts#black_volcanic_beaches_can_be_found_on_maui"
            });


            return (IEnumerable<MAUIFact>)facts;
        });
    }
}
