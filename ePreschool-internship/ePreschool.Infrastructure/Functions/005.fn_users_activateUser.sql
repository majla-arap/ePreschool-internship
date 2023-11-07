CREATE OR REPLACE FUNCTION public.fn_users_activateUser("userId" int , "active" boolean)
    RETURNS VOID
    LANGUAGE plpgsql
AS $function$
BEGIN
	UPDATE "AspNetUsers" 
	SET "Active" = "active"
	WHERE "Id" = "userId";
	
END;
$function$;