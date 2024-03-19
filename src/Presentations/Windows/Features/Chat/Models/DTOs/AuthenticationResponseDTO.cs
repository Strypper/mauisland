namespace MAUIsland;

public record AuthenticationResponseDTO(string id,
                                        DateTime requestAt,
                                        string accessToken,
                                        double expireIn);
