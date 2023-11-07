CREATE OR REPLACE FUNCTION public.fn_parent_getparentbyemail("mail" text)
    RETURNS SETOF "Parents"
    LANGUAGE plpgsql
AS $function$
BEGIN
	RETURN QUERY
	SELECT * FROM "Parents" WHERE "Email"="mail";
END; 
$function$;